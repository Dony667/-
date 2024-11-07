public class TV
{
    public void On()
    {
        Console.WriteLine("");
    }
    
    public void Off()
    {
        Console.WriteLine("");
    }

    public void SetChannel(int channel)
    {
        Console.WriteLine("");
    }
}

public class AudioSystem
{
    public void On()
    {
        Console.WriteLine("");
    }

    public void Off()
    {
        Console.WriteLine("");
    }

    public void SetVolume(int level)
    {
        Console.WriteLine("");
    }
}

public class DVDPlayer
{
    public void Play()
    {
        Console.WriteLine("");
    }

    public void Pause()
    {
        Console.WriteLine("");
    }

    public void Stop()
    {
        Console.WriteLine("");
    }
}

public class GameConsole
{
    public void On()
    {
        Console.WriteLine("");
    }

    public void StartGame()
    {
        Console.WriteLine("");
    }
}

public class HomeTheaterFacade
{
    private readonly TV _tv;
    private readonly AudioSystem _audio;
    private readonly DVDPlayer _dvd;
    private readonly GameConsole _gameConsole;

    public HomeTheaterFacade(TV tv, AudioSystem audio, DVDPlayer dvd, GameConsole gameConsole)
    {
        _tv = tv;
        _audio = audio;
        _dvd = dvd;
        _gameConsole = gameConsole;
    }

    public void WatchMovie()
    {
        _tv.On();
        _audio.On();
        _dvd.Play();
        Console.WriteLine("");
    }

    public void StopMovie()
    {
        _dvd.Stop();
        _audio.Off();
        _tv.Off();
        Console.WriteLine("");
    }

    public void PlayGame()
    {
        _gameConsole.On();
        _tv.On();
        Console.WriteLine("");
    }

    public void StopGame()
    {
        _gameConsole.On();
        _tv.Off();
        Console.WriteLine("");
    }
}

class Program
{
    static void Main(string[] args)
    {
        TV tv = new TV();
        AudioSystem audio = new AudioSystem();
        DVDPlayer dvd = new DVDPlayer();
        GameConsole gameConsole = new GameConsole();

        HomeTheaterFacade homeTheater = new HomeTheaterFacade(tv, audio, dvd, gameConsole);

        homeTheater.WatchMovie();
        homeTheater.StopMovie();
        homeTheater.PlayGame();
        homeTheater.StopGame();
    }
}
