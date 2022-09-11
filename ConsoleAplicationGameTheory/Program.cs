Console.WriteLine("Enter Matriz");
string line = string.Empty;
List<List<Points>> lines = new List<List<Points>>();
//do
//{
//    line = Console.ReadLine();
//    if (!string.IsNullOrEmpty(line))
//    {
//        List<Points> LinePoints = line.Split(";").Select(x => new Points(int.Parse(x.Split(",")[0]), int.Parse(x.Split(",")[1]))).ToList();
//        lines.Add(LinePoints);
//    }

//} while (!string.IsNullOrEmpty(line));

lines.Add(new List<Points>()
{
    new Points(0,0),
    new Points(10,1)
});
lines.Add(new List<Points>()
{
    new Points(1,10),
    new Points(5,5)
});

PrintPoints(lines);

Console.WriteLine("\nGenerate Elimination 1");
int index = getIndexWorstOption(lines, 1);
removeWrostChoice(lines, index, 1);
PrintPoints(lines);
Console.WriteLine("\nGenerate Elimination 2");
index = getIndexWorstOption(lines, 2);
removeWrostChoice(lines, index, 2);
PrintPoints(lines);

void removeWrostChoice(List<List<Points>> lines, int indexRemove ,int interation)
{
    if (interation % 2 == 0)//play 2
    {
        foreach (var line in lines)
        {
            line.RemoveAt(indexRemove);
        }
    }
    else//play 1
    {
        lines.RemoveAt(indexRemove);
    }
}

static void PrintPoints(List<List<Points>> lines)
{
    Console.WriteLine("         |  Player 2");
    Console.WriteLine("_________|____________________");
    Console.WriteLine("Player 1 |");
    foreach (var line in lines)
    {
        Console.Write($"         |");
        foreach (var points in line)
        {
            Console.Write($"({points.p1.ToString("D2")} / {points.p2.ToString("D2")})\t");
        }
        Console.WriteLine();
    }
}

int getIndexWorstOption(List<List<Points>> lines, int interationElimination)
{
    int index = 0;

    if(interationElimination % 2 == 0)//verify colum and play 2
    {
        var columns = lines.ElementAt(0).Count;
        int[] sums = new int[columns];

        for (int coluna = 0; coluna < columns; coluna++)
        {
            foreach (var line in lines)
            {
                sums[coluna] += line.ElementAt(coluna).p2;
            }
        }

        int minValue = sums.ToList().Max();
        index = sums.ToList().IndexOf(minValue);
    }
    else//verify line and play 1
    {
        var sums = lines.Select(x => x.Sum(y => y.p1)).ToList() ;
        int minValue = sums.Max();
        index = sums.IndexOf(minValue);
    }

    return index;
}

public class Points
{
    public int p1;
    public int p2;
    public Points(int pointP1, int pointP2)
    {
        p1 = pointP1;
        p2 = pointP2;
    }
}
