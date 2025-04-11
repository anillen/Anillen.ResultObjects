# Result Object для .NET

[![NuGet Version](https://img.shields.io/nuget/v/Anillen.ResultObjects?style=flat-square)](https://www.nuget.org/packages/Anillen.ResultObjects)
[![CI/CD](https://github.com/anillen/Anillen.ResultObjects/actions/workflows/deploy.yml/badge.svg)](https://github.com/anillen/Anillen.ResultObjects/actions)

Простая и удобная реализация паттерна **Result Object** для .NET, позволяющая обрабатывать ошибки без использования исключений.

## 📦 Установка

```bash
dotnet add package Anillen.ResultObjects
```

## 🎯 Зачем использовать Result Object?

Традиционный подход с исключениями:
- Нарушает поток выполнения
- Дорогостоящий по производительности
- Неявно описывает возможные ошибки

**Result Object** решает эти проблемы, предоставляя:
- Явное описание успешных/неуспешных операций
- Функциональный подход к обработке ошибок
- Легковесную альтернативу исключениям

## 📚 Примеры использования

### Базовый сценарий
```csharp
public ResultValue<Customer> GetCustomer(int id)
{
    if (id <= 0)
        return ResultValue.Failure<Customer>(new Error("400", "Id is not valid"));

    var customer = _repository.Find(id);
    return customer is not null 
        ? ResultValue.Success(customer) 
        : ResultValue.Failure<Customer>(new Error("404", "Not found"));
}
```

### Только результат операции
```csharp
public Result SendMessage(string message)
{
    if (string.IsNullOrEmpty(message))
        return Result.Failure(new Error("400", "Message is not valid"));
    try
    {
        _messageService.SendMessage(message);
        return Result.Success();
    } catch(Exception ex)
    {
        return Result.Failure(new Error("SendMessageError", ex.Message));
    }
}
```
---
⭐ Если проект вам понравился, поставьте звезду на GitHub!
