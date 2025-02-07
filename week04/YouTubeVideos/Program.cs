using System;

class Program
{
    static void Main(string[] args)
    {
        VideoLibrary videoLibrary = new VideoLibrary();
        string viewLibrary = videoLibrary.DisplayLibrary();
        Console.WriteLine(viewLibrary);
    }
}