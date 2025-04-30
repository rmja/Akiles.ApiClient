using System.Buffers;
using System.Diagnostics;

namespace System.IO;

internal static class StreamExtensions
{
    public static ValueTask<MemoryLease> ReadToMemoryAsync(
        this Stream stream,
        CancellationToken cancellationToken = default
    ) => ReadToMemoryAsync(stream, sizeHint: -1, null, cancellationToken);

    public static ValueTask<MemoryLease> ReadToMemoryAsync(
        this Stream stream,
        int sizeHint,
        CancellationToken cancellationToken = default
    ) => ReadToMemoryAsync(stream, sizeHint, null, cancellationToken);

    public static async ValueTask<MemoryLease> ReadToMemoryAsync(
        this Stream stream,
        int sizeHint,
        MemoryPool<byte>? memoryPool,
        CancellationToken cancellationToken = default
    )
    {
        var pool = memoryPool ?? MemoryPool<byte>.Shared;
        var buffer = stream.CanSeek ? pool.Rent((int)stream.Length) : pool.Rent(sizeHint);

        var pos = 0;
        while (true)
        {
            var len = await stream.ReadAsync(buffer.Memory[pos..], cancellationToken);
            if (len == 0)
            {
                break;
            }

            pos += len;

            if (stream.CanSeek && pos == stream.Length)
            {
                Debug.Assert(stream.Position == stream.Length);
                break;
            }
            else if (pos == buffer.Memory.Length)
            {
                // Increase the buffer
                using var oldBuffer = buffer;
                buffer = pool.Rent(oldBuffer.Memory.Length * 2);
                oldBuffer.Memory.CopyTo(buffer.Memory);
            }
        }

        return new MemoryLease(buffer, pos);
    }
}

internal sealed class MemoryLease : IMemoryOwner<byte>
{
    private readonly IMemoryOwner<byte> _owner;
    private readonly int _length;

    public Memory<byte> Memory => _owner.Memory[.._length];

    internal MemoryLease(IMemoryOwner<byte> owner, int length)
    {
        _owner = owner;
        _length = length;
    }

    public void Dispose() => _owner.Dispose();
}
