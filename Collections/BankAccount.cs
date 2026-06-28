//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Collections
//{
//    internal class BankAccount
//    {

//            private decimal _balance; //В цій стрічці зберігається стан рахунку. Щоб його не можна було якимось чином ззовні
//                                      //змінювати на пряму тим самим запобігти маніпуляціям з рахунком
//            public string Owner;     //Ця стрічка виводить на екран власника рахунку. Не знаю чи потрібна ця інформація щоб
//                                      //була публічна?
//            public decimal Balance => _balance; //В цій стрічці функція, що повертає баланс, вона тільки для читання даних
//                                                //і зовнішній код не може змінити баланс напряму.
//            public void Deposit(decimal amount) { _balance += amount; } //В цій стрічці користувач поповнює баланс контрольованим способом
//        public void Withdraw(decimal amount)  //В цій стрічці користувач знімає кошти контрольованим способом
//        { if (_balance <= 0)
//            {
//                Console.WriteLine("please top up the account");
//            } else
//            {
//                _balance -= amount;
//            }
//        }
//        private void RecalculateInterest() { /* внутрішня логіка */ }     /*Ця стрічка для якихось внутрішніх розрахунків і користувачу
//                                                                            не потрібний доступ до неї напряму
//                                                                            Тож, ми інкапсулюємо деякі методи і властивості 
//                                                                            при яких зовнішній код (користувач) бачить*/ 

//    }
//}
