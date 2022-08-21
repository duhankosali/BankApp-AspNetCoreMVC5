using Dk.BankApp.Web.Data.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

namespace Dk.BankApp.Web.TagHelpers
{
    [HtmlTargetElement("getAccountCount")]
    public class GetBankAccountCount : TagHelper // Kendi TagHelper sınıfımızı oluşturuyoruz.
    {
        public int ApplicationUserId { get; set; }
        private readonly BankContext _context;
        public GetBankAccountCount(BankContext context)
        {
            _context = context;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var accountCount = _context.Accounts.Count(x=>x.ApplicationUserId == ApplicationUserId);
            var html = $"<span class='badge bg-danger'>{accountCount} </span>";

            output.Content.SetHtmlContent(html);

          
        }
    }
}
