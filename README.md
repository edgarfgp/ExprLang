# ExprLang

This is a simple expression language that supports the following:

```fsharp
type expr = 
  | CstI of int
  | Var of string
  | Let of string * expr * expr
  | Prim of string * expr * expr
```
Based on the book: [Programming Language Concepts](https://link.springer.com/book/10.1007/978-3-319-60789-4) by Peter Sestoft Second Edition

`ExprLang` uses FsLex and FsYacc to generate the lexer and parser.
