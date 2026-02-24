open System

type complex_numb = {real: float; img : float}

let InputComplex() : complex_numb =
    printf "Действительная часть: "
    let r = float(Console.ReadLine())
    printf "Мнимая часть: "
    let i = float(Console.ReadLine())
    {real = r; img = i}

let add (n1 : complex_numb) (n2 : complex_numb) : complex_numb =
    {real = n1.real + n2.real; img = n1.img + n2.img}

let sub (n1 : complex_numb) (n2 : complex_numb) : complex_numb =
    {real = n1.real - n2.real; img = n1.img - n2.img}

let mult (n1 : complex_numb) (n2 : complex_numb) : complex_numb =
    {real = n1.real * n2.real - n1.img * n2.img;
    img = n1.real * n2.img + n1.img * n2.real}

let div (a: complex_numb) (b: complex_numb) : complex_numb =
    let denom = b.real * b.real + b.img * b.img
    if denom = 0.0 then
        printfn "Ошибка: деление на ноль!"
        {real = 0.0; img = 0.0}
    else
        {real = (a.real * b.real + a.img * b.img) / denom;
          img = (a.img * b.real - a.real * b.img) / denom}

let rec power (numb: complex_numb) (n: int) : complex_numb =
    match n with
    | 0 -> { real = 1.0; img = 0.0 }       
    | 1 -> numb                            
    | _ -> mult numb (power numb (n - 1))

let PrintComplex (numb:complex_numb) = 
    if numb.img = 0.0 then
        printfn "%f" (numb.real)
    elif numb.real = 0.0 then
        printfn "%fi" (numb.img)
    else
        printfn "%f + %fi" (numb.real) (numb.img)

[<EntryPoint>]
let main _ =
    printfn "Введите первое число"
    let numb1 : complex_numb = InputComplex()
    PrintComplex numb1
    printf "Выбирете операцию с комплексными числами\nСложение - '+', Вычитание - '-', Умножение - '*', Деление - '/', Возведение в степень - '^':"
    let operation = Console.ReadLine()
    match operation with
    | "+" ->
        printfn "Сложение: "
        printfn "Введите второе число"
        let numb2 : complex_numb = InputComplex();
        PrintComplex numb2
        printf "Результат сложения: "
        PrintComplex (add numb1 numb2)
    | "-" ->
        printfn "Вычитание: "
        printfn "Введите второе число"
        let numb2 : complex_numb = InputComplex()
        PrintComplex numb2
        printf "Результат вычитания: "
        PrintComplex (sub numb1 numb2) 
    | "*" ->
        printfn "Умножение: "
        printfn "Введите второе число"
        let numb2 : complex_numb = InputComplex()
        PrintComplex numb2
        printf "результат умножение: "
        PrintComplex (mult numb1 numb2)
    | "/" ->
        printfn "Деление: "
        printfn "Введите второе число"
        let numb2 : complex_numb = InputComplex()
        PrintComplex numb2
        printf "Результат деления: "
        PrintComplex (div numb1 numb2)
    | "^" -> 
        printfn "Возведение в степень: "
        printf "Введите степень, в которую необходимо возвести число: "
        let n = int(Console.ReadLine())
        printf "Результат возведения в степень: "
        PrintComplex (power numb1 n)
    | _ -> 
        printfn "Некорректный выбор!"
    0