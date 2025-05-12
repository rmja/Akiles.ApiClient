namespace Akiles.ApiClient.ParameterFormatters;

internal class DateTimeOffsetParameterFormatter : UrlParameterFormatter<DateTimeOffset>
{
    protected override string? Format(DateTimeOffset value) => value.ToString("O");
}
