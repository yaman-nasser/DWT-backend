namespace DWT_apiProj.Model
{
    public class Table
    {
        //   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? MyDate { get; set; }
        public string? CheckIn { get; set; }
        public string? BreakOut { get; set; }
        public string? BreakIn { get; set; }
        public string? CheckOut { get; set; }
        public string? Hours { get; set; }
        public string? Type { get; set; }
    }
}
