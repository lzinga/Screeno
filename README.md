# Screeno
Something I made quickly to see a timelapse of my css changes and over all website changes.

#Usage
In your global.asax or wherever you do initalization of your web project place the following:
````csharp
protected void Application_Start()
{
    AreaRegistration.RegisterAllAreas();
    RouteConfig.RegisterRoutes(RouteTable.Routes);
#if DEBUG
    Screeno.Screeno screen = new Screeno.Screeno(@"C:\Temp\ScreenoImages");
#endif
}
````
The ````#if Debug```` will make sure it is only ran in debug mode and images aren't being created on your production server.

Then all you have to do is add a ````[TakeScreen]```` attribute over any View inside a controller like in the example:
````csharp
public class HomeController : Controller
{
  [TakeScreen]
  public ActionResult Index()
  {
      return View();
  }
}
````

# Known Issues
1. It currently takes a picture of the currently active window.
2. When you do a compile the page isn't fully loaded before it takes the screenshot. So you will end up with a blank looking one.

# ToDos
1. Make it so it grabs the proper window on compile instead of the active window.
2. Since it will take an image every refresh (with what ever buffer timer you put in). You might end up with pictures that are
duplicates are just 1 minor thing unchanged. Need to add some checker to not have tons of the same picture. Which should be relativlity
simple by getting the percentage of how many pixels were changed in the image, and only saving images within a threshold. (This threshold
should be set in the settings for Screeno).
3. Instead of passing all arguments into the constructor, make a ScreenoOptions class to accept all options and then let Screeno
class accept that.
