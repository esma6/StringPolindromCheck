using System;
using System.Collections;

namespace StringPolindromCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Metin giriniz ");
            string enteredText = Console.ReadLine();

            ArrayList polindroms = new ArrayList();// Polindrom olanları bu diziye atıyorum.
            string[] words = enteredText.Split(' '); // Kullanıcının girdiği metni split ile bölüyorum.

            for (int i = 0; i < words.Length; i++)
            {
                if (ChechkPolindrom(words[i])) // ChechkPolindrom fonksiyonuna herbir kelimeyi yolluyorum.
                {
                    bool isThereArray = true; // Polindrom olan kelime polindroms dizisinde var mı onu kontrol ediyorum.
                    if (polindroms.Count == 0)// polindroms dizisinde değer yok ise dizide olmama durumunu false yapıyorum ki diziye eklesin.
                        isThereArray = false;

                    for (int j = 0; j < polindroms.Count; j++)
                    {

                        if (words[i] == polindroms[j].ToString())
                        {
                            isThereArray = true;
                            break;
                        }
                        else
                        {
                            isThereArray = false;
                        }

                    }
                    // Eğer dizide yok ise diziye atıyorum.
                    if (isThereArray == false)
                        polindroms.Add(words[i]);
                }
            }
            Console.WriteLine("Girilen metnin içindeki palindrom sayisi:" + polindroms.Count);
            //Polindrom kelimelerin metinde kaç defa tekrar ettiğini bulup yazdırıyorum
            for (int j = 0; j < polindroms.Count; j++)
            {
                int sayac = 1;
                for (int i = 0; i < words.Length; i++)
                { /* Polindromlar dizisine tekrar olmaması adına her polindromu bir kere eklemiştik.
                     Şimdi burada polindromlar dizisindeki her bir elemanın kelimeler dizinde ne kadar tekrar ettiğini kontrol ediyoruz ve ekrana basıyoruz.
                  
                    */
                    if (polindroms[j].ToString() == words[i])
                        sayac++;
                }
                if (sayac > 2) // polindromun metin içindeki tekrar sayısını 1'den fazla ise yazdırıyorum
                {
                    Console.WriteLine(polindroms[j] + " polindromu metinde " + (sayac - 1) + " kez tekrar etmiştir.");
                }
                

            }


            bool ChechkPolindrom(string word) //Polindrom kelimeyi bulan method ,bu metoda yukarıda split ile parçaladığımız her bir kelimeyi yolluyoruz
            {
                bool state = true;
                for (int i = 0; i < word.Length / 2; i++)
                {

                    if (word[i] != word[word.Length - i - 1])
                        state = false;
                }
                if (state == true)
                    return true;

                else
                    return false;
            }
        }
    }
}
