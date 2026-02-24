open System
// Вариант 1
// Найти сумму цифр натурального числа.

//Рекурсивный поиск суммы цифр числа
let rec sum number: int =
    if number = 0
        then 0
    else ((number%10)+sum(number/10))// Нахождение последней цифры числа и сложение с результатом рекурсивного вызова от числа без последней цифры


[<EntryPoint>]
let main _ =
    printfn "Программа находит сумму цифр натурального числа"
    printf "Введите натуральное число: "
    let number = int(Console.ReadLine())
    printf "Сумма чисел равна: %i" (sum number)
    0