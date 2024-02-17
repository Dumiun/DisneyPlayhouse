
namespace DisneyPlayhouseLibrary.Models
{
    public interface ILib_InvoiceLevel3DataModel
    {
        double Big { get; set; }
        DateTime DrawDate { get; set; }
        string InvoiceId { get; set; }
        string Number { get; set; }
        string Roll { get; set; }
        int Small { get; set; }
    }
}