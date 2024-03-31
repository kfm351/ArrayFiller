using System.Diagnostics;

Random random = new Random();
Stopwatch sw = new Stopwatch();

Console.WriteLine("Введите длину массива");
int len = Convert.ToInt32(Console.ReadLine());
int[,] first = new int[len, len];
int[,] second = new int[len, len];

sw.Start();

await FillArrayAsync(first);
await FillArrayAsync(second);
PrintArray(first);
PrintArray(second);

sw.Stop();
Console.WriteLine($"Время выполнения без оптимизации: {sw.Elapsed}\n\n\n");
sw.Restart();

var a = FillArrayAsync(first);
var b = FillArrayAsync(second);
PrintArray(first);
PrintArray(second);
await a;
await b;

sw.Stop();
Console.WriteLine($"Время выполнения с оптимизацией: {sw.Elapsed}");

async Task FillArrayAsync(int[,] array)
{
    await Task.Delay(1000);
    await Task.Run(() =>
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = random.Next(10);
            }
        }
    });
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine("\n");
    }
    Console.WriteLine();
}
