using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HelloCsharpCourseLearning
{
    internal class Dictionery
    {
        static void Main(string[] args)
        {
            string text = "apple banana apple cherry banana apple";

            /* Розбиваємо текст на слова, ігноруючи зайві пробіли: створюємо масив words і в нього записуємо окремі 
             слова з тексту (1. Береться вихідний рядок text. 2. Переглядається кожен символ (new char[]):
                                                                 * Якщо він не є одним із роздільників(' ', '\t', '\n', '\r'), він додається до 
                                                                 поточного слова.
                                                                 * Якщо він є роздільником — поточне слово завершується, і починається нове.
            3. Якщо між словами кілька роздільників поспіль — завдяки RemoveEmptyEntries вони пропускаються. 4. Повертається масив слів.),
            що міститься в змінній text. Метод Split: .Split(...) розбиває рядок на частини(підрядки) за вказаними роздільниками:
            new char[] { ' ', '\t', '\n', '\r' } - (' ' — пробіл), ('\t' — табуляція), ('\n' — символ нового рядка), ('\r' — повернення каретки)
            Тобто, розбиття відбувається там, де де зустрічається будь-який із цих символів
            StringSplitOptions.RemoveEmptyEntries - Цей параметр каже методу ігнорувати порожні елементи у результаті.
            Наприклад, якщо між словами кілька пробілів або табуляцій, вони не створять "порожніх" елементів у масиві.*/

            string[] words = text
                .Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            //Виведемо масив words і глянемо, що там знаходиться //-> apple
            //   banana
            foreach (var item in words)                          //   apple
            {                                                    //   cherry
                Console.WriteLine(item);                          //   banana
            }                                                    //   apple
                                                                 //В результаті Метод повертає масив string[], де кожен елемент — це окреме слово без роздільників.

            /* Словник для підрахунку
            Dictionary<TKey, TValue>: Це словник у C#, який зберігає пари ключ–значення. TKey — тип ключа (string у нашому випадку).
            TValue — тип значення (int у нашому випадку). У цьому прикладі: Ключ — слово (string). Значення — кількість разів,
            скільки це слово зустрічається (int).
            StringComparer.OrdinalIgnoreCase - це спеціальний порівнювач рядків, який: порівнює рядки за їхнім байтовим представленням (Ordinal);
            ігнорує регістр (IgnoreCase) — "Apple" і "apple" вважаються однаковими ключами.*/

            Dictionary<string, int> wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase); /* виклик конструктора класу 
            Dictionary<TKey, TValue> з передачею спеціального параметра — порівнювача ключів. 
            1. Dictionary<string, int> це узагальнений словник (generic dictionary), де: string — тип ключа (слова); int — тип значення (кількість разів,
            скільки слово зустрічається). 2. Конструктор Dictionary(IEqualityComparer<TKey> comparer) - це один із перевантажених конструкторів класу 
            Dictionary.
            Він дозволяє вказати, як саме порівнювати ключі. 3. StringComparer.OrdinalIgnoreCase - це готовий об’єкт, який реалізує інтерфейс
            IEqualityComparer<string> і порівнює рядки: Ordinal — побітове (бінарне) порівняння символів; IgnoreCase — без урахування регістру
            Завдяки цьому:
            wordCount["Apple"] = 1;
            wordCount["apple"]++; // Не створить новий ключ, а збільшить значення існуючого
            */

            foreach (string word in words) //Проходимо по кожному елементу колекції words (це може бути масив або список рядків), word — це поточне слово з колекції.  
            {
                string cleanWord = word.Trim(); //Метод .Trim() видаляє пробіли (та інші непотрібні символи на початку і в кінці рядка).
                if (wordCount.ContainsKey(cleanWord)) /* wordCount — це словник (Dictionary<string, int>),
                                                      де: ключ(string) — слово, значення(int) — кількість разів, коли це слово зустрічається.
                                                      ContainsKey(cleanWord) перевіряє, чи вже є таке слово в словнику. */
                    wordCount[cleanWord]++; //Якщо слово вже є в словнику, збільшуємо його лічильник на 1
                else
                    wordCount[cleanWord] = 1; //Якщо слова ще немає в словнику, додаємо його з початковим значенням 1   


            }

            // Сортування за кількістю (спадання), потім за словом (зростання)
            var sorted = wordCount // Оголошуємо змінну sorted і в ній розміщаємо wordCount
                .OrderByDescending(kv => kv.Value) /* 1. OrderByDescending(kv => kv.Value): - Перше сортування — за значенням у спадному порядку
                                                            Сортує колекцію за значенням (Value) у спадному порядку.
                                                            Тобто слова з більшою кількістю входжень будуть на початку списку.
                                                            kv — це кожна пара ключ-значення (KeyValuePair<string, int>) - Перетворення словника в послідовність пар
                                                            kv.Value — кількість повторень слова. */
                .ThenBy(kv => kv.Key);              /* 2. ThenBy(kv => kv.Key) - Друге сортування — за ключем у зростаючому порядку (ThenBy), якщо значення однакові.
                                                            Якщо кількість входжень (Value) однакова, то сортування відбувається за ключем (Key)
                                                            у зростаючому алфавітному порядку.
                                                            Це другий рівень сортування. */

            // Вивід результату
            foreach (var kv in sorted)              //Цикл, що перебирає Результат — нову впорядкована послідовність (IOrderedEnumerable<KeyValuePair<string,int>>)
            {
                Console.WriteLine($"{kv.Key} = {kv.Value}");
            }

        }
    }
}
