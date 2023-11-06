## Calculable
This classes are facades for `Context` class.

Each property is mapped to an enum of `PropertyEnum` calling `GetOrCalculate` of `Context` class

```csharp
        public string Property
        {
            get
            {
                return context.GetOrCalculate<long>(PropertyEnum.PROPERTY);
            }
        }
```
