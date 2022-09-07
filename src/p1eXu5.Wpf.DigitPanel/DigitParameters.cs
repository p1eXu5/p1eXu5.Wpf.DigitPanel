namespace p1eXu5.Wpf.DigitPanel;

public record DigitParameters
{
    public string Mask { get; init; } = default!;
    public bool Dot { get; set; }
    public bool Colon { get; set; }
}
