using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindZodiac2.Pages;

public class IndexModel : PageModel
{
     
    [BindProperty]
    public int BirthYear { get; set; }
    public string ZodiacName { get; private set; }
    public string ZodiacUrl { get; private set; }
    public string InvalidInput { get; private set; }

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger,string zodiacName,string zodiacUrl, string invalidInput)
    {
        _logger = logger;
        ZodiacName = zodiacName;
        ZodiacUrl=zodiacUrl;
        InvalidInput=invalidInput;

    }

    public void OnGet()
    {

    }
     public void OnPost()
    {
        // Define the range of valid birth years (adjust as needed)
        int minYear = 1900;
        int maxYear = System.DateTime.Now.Year + 1;

        if (BirthYear >= minYear && BirthYear <= maxYear)
        {
            
            ZodiacName = FindZodiac2.Models.Utils.GetZodiac(BirthYear);
            ZodiacUrl = "/images/" + ZodiacName + ".png";                            

        }
        else
        {
            InvalidInput = "Year must be between 1900 and next year. Please try again.";
        }
    }   
}
