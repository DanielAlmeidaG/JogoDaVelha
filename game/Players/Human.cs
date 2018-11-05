using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    public class Human : Player
    {
        int _id;
        List<string> validos = new List<string>();
        public Human(int id)
        {
            this._id = id;
            validos.Add("0");
            validos.Add("1");
            validos.Add("2");
            validos.Add("3");
            validos.Add("4");
            validos.Add("5");
            validos.Add("6");
            validos.Add("7");
            validos.Add("8");
            validos.Add("9");
        }
        public int GetId()
        {
            return _id;
        }
        public int ChoseAction()
        {
            Console.WriteLine("\n--Digite 0 caso deseje sair--");
            Console.WriteLine("Escolha onde deseja jogar(1-9): ");
            var number = Console.ReadLine();            
            while (!validos.Contains(number))
            {
                Console.WriteLine("Escolha apenas numeros entre 1 e 9!!");
                number = Console.ReadLine();
            }
            Int32.TryParse(number, out int intNumber);
            return intNumber;
        }
    }
}
