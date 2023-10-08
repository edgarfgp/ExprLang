(* File Expr/Program.fs *)
(* Lexing and parsing of simple expressions using fslex and fsyacc *)

open System.IO
open FSharp.Text

open Absyn

(* Plain parsing from a string, with poor error reporting *)

let fromString (str : string) : expr =
    let lexbuf = Lexing.LexBuffer<char>.FromString(str)
    try 
      Parser.Main Lexer.Token lexbuf
    with
    | exn ->
        let pos = lexbuf.EndPos 
        failwithf $"%s{exn.Message} near line %d{pos.Line+1}, column %d{pos.Column}\n"
             
(* Parsing from a text file *)
let fromFile (filename : string) =
    use reader = new StreamReader(filename)
    let lexbuf = Lexing.LexBuffer<char>.FromTextReader reader
    try 
      Parser.Main Lexer.Token lexbuf
    with
    | exn ->
        let pos = lexbuf.EndPos 
        failwithf $"%s{exn.Message} in file %s{filename} near line %d{pos.Line+1}, column %d{pos.Column}\n"

let expr = fromString """
let x = 5
"""

printfn $"{exp}"