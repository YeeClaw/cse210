using System.Diagnostics;
using System.Numerics;

namespace Sandbox;

/// <summary>
/// Basic text animation class that can be used to display text animations in the console.
/// </summary>
public class TextAnimation
{
    public int Fps { get; set; }
    public string[] Frames { get; set; }
    public string[] ReverseFrames { get; }
    
    /// <param name="fps">
    /// The frames per second that the animation should be played at.
    /// </param>
    /// <param name="frames">
    /// The frames that the animation should be played with represented as an array of strings.
    /// </param>
    public TextAnimation(int fps, string[] frames)
    {
        Fps = fps;
        Frames = frames;
        ReverseFrames = (string[])Frames.Clone();
        Array.Reverse(ReverseFrames);
    }

    /// <summary>
    /// Repositions the cursor to where it was before the last frame was drawn and erases each line of the last frame.
    /// </summary>
    /// <param name="frame">Old frame to be erased</param>
    /// <param name="prevCursorPos">A Vector2 representing the position where the frame started it's draw.</param>
    private void EraseLastFrame(string frame, Vector2 prevCursorPos)
    {
        int deltaX = Console.CursorLeft - (int)prevCursorPos.X;
        int deltaY = Console.CursorTop - (int)prevCursorPos.Y;
        
        Console.SetCursorPosition((int)prevCursorPos.X, (int)prevCursorPos.Y);
        for (var i = 0; i <= deltaY; i++)
        {
            Console.WriteLine(new string(' ', deltaX));
        }
        Console.SetCursorPosition((int)prevCursorPos.X, (int)prevCursorPos.Y);
    }
    
    /// <summary>
    /// Plays a text based animation in the console. This method will loop through the frames of the animation exactly
    /// once unless specified with the `duration` parameter (see overload).
    /// </summary>
    public async Task Play()
    {
        var endTime = DateTime.Now.AddSeconds((double)Frames.Length / Fps);
        while (true)
        {
            foreach (var frame in Frames)
            {
                int prevConsoleX = Console.CursorLeft;
                int prevConsoleY = Console.CursorTop;
                
                Console.Write(frame);
                await Task.Delay(1000 / Fps);
                EraseLastFrame(frame, new Vector2(prevConsoleX, prevConsoleY));
                if (DateTime.Now > endTime) // This set up seems weird, but it ensures that the animation will play EXACTLY as long as it should.
                {
                    return;
                }
            }
        }
    }
    
    /// <summary>
    /// Overload of `Play()` with specified duration. This is necessary because a default parameter requires a
    /// compile time constant which isn't possible to define for an instanced object.
    /// </summary>
    /// <param name="duration">
    /// The duration that the animation should play.
    /// </param>
    public async Task Play(double duration)
    {
        var startTime = DateTime.Now;
        var endTime = DateTime.Now.AddSeconds(duration);
        while (true)
        {
            foreach (var frame in Frames)
            {
                int prevConsoleX = Console.CursorLeft;
                int prevConsoleY = Console.CursorTop;
                
                Console.Write(frame);
                await Task.Delay(1000 / Fps);
                EraseLastFrame(frame, new Vector2(prevConsoleX, prevConsoleY));
                if (DateTime.Now > endTime) // Documented in default overload.
                {
                    // Console.WriteLine($"Animation duration exceeded at {DateTime.Now - startTime} seconds.");
                    return;
                }
            }
        }
    }

    public async Task ReversePlay()
    {
        var endTime = DateTime.Now.AddSeconds((double)ReverseFrames.Length / Fps);
        while (true)
        {
            foreach (var frame in ReverseFrames)
            {
                int prevConsoleX = Console.CursorLeft;
                int prevConsoleY = Console.CursorTop;
                
                Console.Write(frame);
                await Task.Delay(1000 / Fps);
                EraseLastFrame(frame, new Vector2(prevConsoleX, prevConsoleY));
                if (DateTime.Now > endTime)
                {
                    return;
                }
            }
        }
    }
}