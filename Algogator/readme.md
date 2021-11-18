## Description
Algogator is a simple library enable to use different math or it algorithms in different problem solving areas. 

## Sorting algorithms
- Insertion Sort
- Bubble Sort
- Merge Sort

## Version
- C# 8.0
- .NET core 3.x
- Visual Studio 2019


## How to use

Declare ISorting<T> object. Then choose sorting method. One can optionally add method to event (it will be called each iteration).

**Example**

```C#
//arr - array of strings
ISorting<string> s = new ISorting<string>(ref arr, (string s1, string s2)=> {return s1.Length>s2.Length;});

//(optional)add method displaying current order to event
s.SortIterated+=(s,EventArgs)=>{
    foreach(var item in s.getArray()){
    Console.Write($"{item} ");
}
Console.WriteLine();
}

s.sort();
```
## Technologies
- **Observation pattern**
In Algogator project *observation pattern* has been used. Each sorting method is equipped in subscribe method *OnIterated*. The method is called in each iteration. Thus an event is raised each time when the iteration takes place.

**Example of using event**
```C#

//sortingObj - sorting object

sortingObj.SortIterated+=(sortingObj,EventArgs) => { Console.WriteLine("iteration"); };
```

- **Interfaces and abstract class**. Each sorting method is implemented by new class. However there is base interface ISorting enabling to cast sorting object of different methods to one common type.

- **Events and delegates.** Event is used to implement observation pattern described above. In order to sort one need to pass *recipe for comparing two objects* as delegate.

**Example of using delegate (look at lambda expression)**
```C#
//arr - array

//increasing
ISorting<int> s1 = (ISorting<int>)new SortingInsertion<int>(ref arr, (int x, int y) => { return x > y; });

//decreasing
ISorting<int> s2 = (ISorting<int>)new SortingInsertion<int>(ref arr, (int x, int y) => { return x < y; });
```

**Generic types.** Sorting methods enables to sort each type. One only need to define type and define comparing method for the type (look above).

## To Be
In the future it's planned to add next sorting algorithms.