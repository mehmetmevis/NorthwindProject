using System.ComponentModel.DataAnnotations;

namespace MvcWebUI.Models
{
    public class ShippingDetail
    {
        //[Required(ErrorMessage = "Lütfen ad alanını doldurunuz.")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = "Lütfen soyad alanını doldurunuz.")]
        public string LastName { get; set; }
        //[DataType(DataType.EmailAddress, ErrorMessage = "Lütfen geçerli bir e-mail adresi giriniz.")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Lütfen şehir alanını doldurunuz.")]
        public string City { get; set; }
        //[Required(ErrorMessage = "Lütfen adress alanını doldurunuz.")]
        public string Address { get; set; }
        //[Range(18, 65, ErrorMessage = "Lütfen geçerli bir yaş giriniz.")]
        public int Age { get; set; }
    }
}
