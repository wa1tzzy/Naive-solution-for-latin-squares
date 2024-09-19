using System;
using System.Collections.Generic;
using System.Diagnostics;

class LatinSqaureSolver
{
    private int n;
    private char[,] grid;
    private List<char> alphabet = new List<char>();

    public LatinSqaureSolver(int size, char[,] partialGrid) {
        n = size;
        grid = partialGrid;
        initAlphabet(); 
    }

    // Method to initialize the alphabet based on sqaure size
    private void initAlphabet() {
        string s = "";
        for (int i = 0; i < n; i++) {
            s += (char)(i + 65) + " "; 
            alphabet.Add((char)(i + 65));
        }
        Debug.WriteLine("Alphabet = " + s);
    }

    // Method to print the current sqaure
    public void gridPrinter() {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                Console.Write(grid[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // Checking if placing 'letter' in grid[i, j] is valid (no duplicates in row and column)
    private bool isPlacementValid(int row, int col, char letter) {
        for (int i = 0; i < n; i++) {
            if (grid[row, i] == letter) return false;
        }
        for (int i = 0; i < n; i++) { 
            if (grid[i, col] == letter) return false;
        }

        return true;
    }

    // tring to solve the partially filled Latin sqaure with backtracking
    public bool solve() {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i, j] == '.') {
                    foreach (char letter in alphabet) {
                        if (isPlacementValid(i, j, letter)){
                            grid[i, j] = letter;

                            if (solve()) {
                                return true;
                            }
                            grid[i, j] = '.';
                        }
                    }
                    return false; 
                }
            }
        }
        return true; 
    }
}

class Program {
    static void Main(string[] args) {
        int n = 4;

        char[,] grid = {
            { 'A', '.', '.', 'C' },
            { '.', 'C', '.', '.' },
            { '.', '.', 'B', '.' },
            { 'D', '.', '.', 'B' }
        };

        LatinSqaureSolver sqaure = new LatinSqaureSolver(n, grid);

        Console.WriteLine("Input Grid:");
        sqaure.gridPrinter();

        if (sqaure.solve()) {
            Console.WriteLine("\nSolved Grid:");
            sqaure.gridPrinter();
        }
        else {
            Console.WriteLine("No solution exists.");
        }
    }
}
