using System;
using System.Collections.Generic;

public abstract class SeasonSubject
{
    private List<ISeasonObserver> observers = new List<ISeasonObserver>();

    public void RegisterObserver(ISeasonObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(ISeasonObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (ISeasonObserver observer in observers)
        {
            observer.Update();
        }
    }
}

public class ConcreteSeasonSubject : SeasonSubject
{
    private string currentSeason;

    public string CurrentSeason
    {
        get { return currentSeason; }
        set
        {
            currentSeason = value;
            NotifyObservers();
        }
    }
}

public interface ISeasonObserver
{
    void Update();
}

public class House : ISeasonObserver
{
    public void Update()
    {
        Console.WriteLine("Вигляд будинку змінився на поточну пору року.");
    }
}

public class Trees : ISeasonObserver
{
    public void Update()
    {
        Console.WriteLine("Вигляд дерев змінився на поточну пору року.");
    }
}

public class Flowers : ISeasonObserver
{
    public void Update()
    {
        Console.WriteLine("Вигляд квітів змінився на поточну пору року.");
    }
}

public class Fence : ISeasonObserver
{
    public void Update()
    {
        Console.WriteLine("Вигляд паркану змінився на поточну пору року.");
    }
}

public class Birds : ISeasonObserver
{
    public void Update()
    {
        Console.WriteLine("Вигляд паркану змінився на поточну пору року.");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        ConcreteSeasonSubject seasonSubject = new ConcreteSeasonSubject();

        House house = new House();
        Trees trees = new Trees();
        Flowers flowers = new Flowers();
        Fence fence = new Fence();
        Birds birds = new Birds();
       
        seasonSubject.RegisterObserver(house);
        seasonSubject.RegisterObserver(trees);
        seasonSubject.RegisterObserver(flowers);
        seasonSubject.RegisterObserver(fence);
        seasonSubject.RegisterObserver(birds);

        seasonSubject.CurrentSeason = "Весна";

        seasonSubject.CurrentSeason = "Весна";
        seasonSubject.CurrentSeason = "Осінь";
        seasonSubject.CurrentSeason = "Зима";

        seasonSubject.UnregisterObserver(flowers);
        Console.ReadKey();
    }
}
