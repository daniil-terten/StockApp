# StockApp
* Построить иерархию классов, описывающих объекты на складе - паллеты и коробки.
* Помимо общего набора стандартных свойств (Id, ширина, высота, глубина, вес), паллета может содержать в себе коробки.
* У коробки должен быть указан срок годности или дата производства. Если указана дата производства, то срок годности вычисляется из даты производства плюс 100 дней.
* Срок годности паллеты вычисляется из наименьшего срока годности коробки, вложенной в паллету. Вес паллеты вычисляется из суммы веса вложенных коробок + 30кг.
* Объем коробки вычисляется как произведение ширины, высоты и глубины.
* Объем паллеты вычисляется как сумма объема всех коробок и произведения ширины, высоты и глубины паллеты.
* Организовать запись и чтение коллекции в/из файл (хотя бы в общем виде).
* Сгруппировать все паллеты по сроку годности, отсортировать по возрастанию срока годности, в каждой группе отсортировать паллеты по весу. Результат вывести на экран.
* Вывести на экран 3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема.
* Покрыть unit-тестами
