//The problem is that we have to support multiplatform UI.
//We have Dialog class which has CreateButton() method/
//Using Factory method pattern create the button for the OS or platform the application is running.


Dialog dialog = null;
var config = 1; // some random value

if (config == (int)Config.Windows)
    dialog = new WindowsDialog();
else if (config == (int)Config.Web)
    dialog = new WebDialog();
else
    throw new Exception("not supproted");

dialog.CreateButton();
Console.WriteLine($"You run {(Config)config} application. The button created should be apropriate to the type of application.");


/// <summary>
/// Simulating application configs.
/// </summary>
enum Config
{
    Windows,
    Web
}

class Dialog
{
    //The factory method
    public virtual IButton CreateButton()
    {
        Console.WriteLine("Default button created");
        return new DefaultButton();
    }

    public void Render()
    {
        var okBtn = CreateButton();
        okBtn.OnClick();
        okBtn.Reander();
    }
}

class WindowsDialog : Dialog
{
    //Facotry method concrete type creation
    public override IButton CreateButton()
    {
        Console.WriteLine("Windows button created");
        return new WindowsButton();
    }
}

class WebDialog : Dialog
{
    //Facotry method concrete type creation
    public override IButton CreateButton()
    {
        Console.WriteLine("Html button created");
        return new HtmlButton();
    }
}


// For default factory method
class DefaultButton : IButton
{
    public void OnClick()
    {
        throw new NotImplementedException();
    }

    public void Reander()
    {
        throw new NotImplementedException();
    }
}

class WindowsButton : IButton
{
    public void OnClick()
    {
        throw new NotImplementedException();
    }

    public void Reander()
    {
        throw new NotImplementedException();
    }
}

class HtmlButton : IButton
{
    public void OnClick()
    {
        throw new NotImplementedException();
    }

    public void Reander()
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// The blueprint of Products
/// </summary>
interface IButton
{
    void Reander();
    void OnClick();
}