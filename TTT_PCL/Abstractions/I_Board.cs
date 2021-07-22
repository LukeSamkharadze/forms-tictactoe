using TTT_PCL.Other;

namespace TTT_PCL.Abstractions
{
    public interface I_Board
    {
        string[,] Board { get; }

        bool Place(string item, S_Cordinate2D cordinate2D);

        string Take(S_Cordinate2D cordinate2D);
    }
}