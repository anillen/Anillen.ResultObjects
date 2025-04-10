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
public Result<Customer> GetCustomer(int id)
{
    if (id <= 0)
        return Result.Failure<Customer>(new Error("400", "Id is not valid"));

    var customer = _repository.Find(id);
    return customer != null 
        ? Result.Success(customer) 
        : Result.Failure<Customer>(new Error("404", "NotFoundError"));
}
```

## 🤝 Как внести вклад

1. Форкните репозиторий
2. Создайте ветку для вашей фичи (`git checkout -b feature/AmazingFeature`)
3. Сделайте коммит изменений (`git commit -m 'Add some AmazingFeature'`)
4. Запушьте ветку (`git push origin feature/AmazingFeature`)
5. Откройте Pull Request

---
⭐ Если проект вам понравился, поставьте звезду на GitHub!
