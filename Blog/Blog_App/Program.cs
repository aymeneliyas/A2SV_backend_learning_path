using Blog_App;
using Blog_App.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

class Program
{
    static void Main()
    {
        var context = new ApiDbContext();
        MainMenu menu = new MainMenu(context);
        menu.Start();
    }
}