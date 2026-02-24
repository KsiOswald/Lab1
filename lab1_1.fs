open System
// Вариант 1
// Создать список из двух чередующихся символов (символы вводятся с клавиатуры)

[<EntryPoint>]
let main _ =
    printfn "Программа создает список из N чередующихся символов"
    printf "Введите количество символов: "
    let n = int(Console.ReadLine()) 
    if n <=0 then printf "Неверный ввод"
    else
        printf "Введите первый символ: "
        let first_ch = Console.ReadLine() 
        printf "Введите второй символ: "
        let second_ch = Console.ReadLine()
        let list =
            [
                for i in 1..n do// Цикл, в котором происходит по-очерёдная вставка символов в список
                if (i%2 = 1) then yield first_ch
                else yield second_ch
            ]
        printf "Итоговый список: %A" list
    0