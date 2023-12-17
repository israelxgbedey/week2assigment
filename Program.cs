using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string directoryPath = Path.Combine(projectDirectory, "TextFiles");

        ProcessFiles(directoryPath);
    }

    static void ProcessFiles(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            string[] files = Directory.GetFiles(directoryPath, "*.txt");

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                Console.WriteLine($"Processing file: {fileName}");

                Dictionary<char, int> charCount = CountCharacters(file);

                Console.WriteLine("Character counts (excluding spaces):");
                foreach (var entry in charCount)
                {
                    Console.WriteLine($"Character: '{entry.Key}', Count: {entry.Value}");
                }

                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine($"Directory '{directoryPath}' not found.");
        }
    }

    static Dictionary<char, int> CountCharacters(string filePath)
    {
        Dictionary<char, int> charCount = new Dictionary<char, int>();

        try
        {
            string content = File.ReadAllText(filePath);

            foreach (char c in content)
            {
                if (c != ' ')
                {
                    if (charCount.ContainsKey(c))
                    {
                        charCount[c]++;
                    }
                    else
                    {
                        charCount[c] = 1;
                    }
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error reading file: {e.Message}");
        }

        return charCount;
    }
}
