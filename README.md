# Генерация отчетов
<b>Возможные ограничения компилятора Unity IL2CPP:</b>

- <b>Нулевые проверки:</b> Если этот параметр включен, код C++, сгенерированный IL2CPP, будет содержать проверки на null и при необходимости создавать управляемые исключения NullReferenceException. Если этот параметр отключен, нулевые проверки не будут генерироваться в сгенерированном коде C++. Для некоторых проектов отключение этого параметра может улучшить производительность во время выполнения. Однако любой доступ к нулевым значениям в сгенерированном коде не будет защищен и может привести к некорректному поведению. Обычно игра вылетает вскоре после разыменования нулевого значения, но мы не можем этого гарантировать. Отключите эту опцию с осторожностью.
- <b>Проверка границ массива:</b> Если этот параметр включен, код C++, сгенерированный IL2CPP, будет содержать проверки границ массива и при необходимости создавать управляемые исключения IndexOutOfRangeException. Если этот параметр отключен, проверки границ массива не будут включены в сгенерированный код C++. Для некоторых проектов отключение этого параметра может улучшить производительность во время выполнения. Однако любой доступ к массиву с недопустимыми индексами в сгенерированном коде не будет защищен и может привести к некорректному поведению, включая чтение или запись в произвольные области памяти. В большинстве случаев эти обращения к памяти будут происходить без каких-либо немедленных побочных эффектов и могут незаметно испортить состояние игры. Отключайте эту опцию с особой осторожностью.
- <b>Проверка деления на ноль:</b> Если этот параметр включен, код C++, сгенерированный IL2CPP, будет содержать проверки деления на ноль для целочисленного деления и при необходимости создавать управляемые исключения DivideByZeroException. Если этот параметр отключен, проверки деления на ноль при целочисленном делении не будут генерироваться в сгенерированном коде C++. Для большинства проектов эту опцию следует отключить. Включайте его только в том случае, если требуются проверки деления на ноль, так как эти проверки имеют затраты времени выполнения.
- <b>Переполнение кеша (не удалось извлечь ресурсы, необходимые для IL2CPP)</b> 

## <b>Анализ существующих решений и инструментариев, которые могут пригодиться в работе</b>
