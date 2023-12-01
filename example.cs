using System;

    //# Cadenas aceptadas por el automata
    // "ab"
    // "bab"
    // "aab"
    // "aaab"
    // "babab"
class Program
{
    static void Main()
    {
        // Definir el alfabeto y el conjunto de estados
        char[] alfabeto = { 'a', 'b' };
        int[] estados = { 0, 1, 2 };

        // Definir la función de transición (tabla de transiciones)
        int[,] transiciones = {
            {1, 0}, // Desde el estado 0, 'a' lleva al estado 1, 'b' lleva al estado 0
            {1, 2}, // Desde el estado 1, 'a' lleva al estado 1, 'b' lleva al estado 2
            {1, 0}  // Desde el estado 2, 'a' lleva al estado 1, 'b' lleva al estado 0
        };

        // Estado inicial y conjunto de estados de aceptación
        int estadoInicial = 0;
        int[] estadosDeAceptacion = { 2 };

        // Cadena de entrada
        Console.Write("Ingrese una cadena: ");
        string cadena = Console.ReadLine();

        // Verificar si la cadena es aceptada por el AFD
        bool esAceptada = VerificarCadena(alfabeto, estados, transiciones, estadoInicial, estadosDeAceptacion, cadena);

        // Mostrar el resultado
        if (esAceptada)
            Console.WriteLine("La cadena es aceptada por el AFD.");
        else
            Console.WriteLine("La cadena no es aceptada por el AFD.");
    }

    static bool VerificarCadena(char[] alfabeto, int[] estados, int[,] transiciones, int estadoInicial, int[] estadosDeAceptacion, string cadena)
    {
        int estadoActual = estadoInicial;

        foreach (char caracter in cadena)
        {
            int indiceCaracter = Array.IndexOf(alfabeto, caracter);
            if (indiceCaracter == -1)
            {
                Console.WriteLine("Error: El caracter '{0}' no pertenece al alfabeto.", caracter);
                return false;
            }

            estadoActual = transiciones[estadoActual, indiceCaracter];
        }

        return Array.IndexOf(estadosDeAceptacion, estadoActual) != -1;
    }
}
