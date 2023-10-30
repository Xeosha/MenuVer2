using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class Options
    {
        public string Text { get; set; }

        public Action Function { get; set; }

        
        public Options(string text, Action newFucntion)
        {
            this.Text = text;
            this.Function = newFucntion;
        }
    }
    public class Dialog
    {

        List<Options> _options;
        string _message;

        public Dialog(Options[] options)
        {
            _options = new List<Options>(options);
        }

        public Dialog(Options[] options, string message)
        {
            _options = new List<Options>(options);
            _message = message;
        }

        public void AddOption(Options opt)
        {
            _options.Add(opt);
        }

        private void ShowTextDialog(int index)
        {
            Console.Clear();
            Console.WriteLine("- Для выхода нажмите из меню нажмите ESC. Из подменю ESC 2 раза.");
            Console.WriteLine("- Для перемещения используйте стрелочки вверх и вниз");
            Console.WriteLine("- Для входа в опцию нажмите ENTER");
            Console.WriteLine();

            if (_message != null)
                Console.WriteLine($"\t{_message}");
            for (int i = 0; i < _options.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(">> ");
                }
                Console.WriteLine(_options[i].Text);
                Console.ResetColor();

            }
            Console.WriteLine();
        }

        private void ShowDialog()
        {
            bool isContinue = true;
            int index = 0;

            while (isContinue)
            {
                ShowTextDialog(index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < _options.Count - 1)
                            index++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine($"> Выбран пункт {_options[index].Text}\n");
                        _options[index].Function();
                        Console.WriteLine("\n> Нажмитие esc для выхода");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.Escape:
                        isContinue = false;
                        break;

                }

            }
        }

        public void Start() => ShowDialog();

    }
}
