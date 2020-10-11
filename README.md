# Significant-Figure-Calculator
 A small library for calculating expressions with significant figure

# Usage
A `SigFigCalculator` object must be created.  Then with this object call `Evaluate(string expression)` on it passing the expression.  You will be returned a `SigFigCalculatorResult` which will have a value indicating Success, the unrounded and rounded values, and if applicable, an error message.

Due to how to the logic is built when mixing addition/subtraction and multiplication/division the number with the lowest number of sig figs will be used even if that number is used in addtion or subtraction.

For example: `(5.00 + 5.7) * 6.65` using sig fig rules should yield 71.2, but the calculator will return 71.  To counter this numbers can be "escaped" so they can't be used as the number with the lowest amount of sig figs.  The escape character is 'a' so `(a5.00 + a5.7) * 6.65` would return the correct number.  This escaping functionality is useful for other cases such as conversion factors as well.

# Credits
The underlying math engine is based on https://medium.com/@toptensoftware/writing-a-simple-math-expression-engine-in-c-d414de18d4ce
