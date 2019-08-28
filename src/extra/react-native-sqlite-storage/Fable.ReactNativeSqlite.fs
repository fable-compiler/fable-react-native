namespace rec Fable.ReactNativeSqlite

open Fable.Core.JsInterop

open System
open Fable.Core
open Fable.Core.JS


type [<AllowNullLiteral>] IExports =
    abstract DEBUG: isDebug: bool -> unit
    abstract enablePromise: enablePromise: bool -> unit
    abstract openDatabase: ``params``: DatabaseParams -> Promise<SQLiteDatabase>
    abstract deleteDatabase: ``params``: DatabaseParams -> Promise<unit>

type [<StringEnum>] [<RequireQualifiedAccess>] Location =
    | Default
    | [<CompiledName "Library">] Library
    | [<CompiledName "Documents">] Documents

type [<AllowNullLiteral>] DatabaseOptionalParams =
    abstract createFromLocation: U2<float, string> option with get, set
    abstract key: string option with get, set
    abstract readOnly: bool option with get, set

type [<AllowNullLiteral>] DatabaseParams =
    inherit DatabaseOptionalParams
    abstract name: string with get, set
    /// Affects iOS database file location
    /// 'default': Library/LocalDatabase subdirectory - NOT visible to iTunes and NOT backed up by iCloud
    /// 'Library': Library subdirectory - backed up by iCloud, NOT visible to iTunes
    /// 'Documents': Documents subdirectory - visible to iTunes and backed up by iCloud
    abstract location: Location with get, set

type [<AllowNullLiteral>] ResultSet =
    abstract insertId: int with get, set
    abstract rowsAffected: int with get, set
    abstract rows: ResultSetRowList with get, set

type [<AllowNullLiteral>] ResultSetRowList =
    abstract length: int with get, set
    abstract item: index: int -> obj option

type [<RequireQualifiedAccess>] SQLErrors =
    | UNKNOWN_ERR = 0
    | DATABASE_ERR = 1
    | VERSION_ERR = 2
    | TOO_LARGE_ERR = 3
    | QUOTA_ERR = 4
    | SYNTAX_ERR = 5
    | CONSTRAINT_ERR = 6
    | TIMEOUT_ERR = 7

type [<AllowNullLiteral>] SQLError =
    abstract code: float with get, set
    abstract message: string with get, set

type [<AllowNullLiteral>] StatementCallback =
    [<Emit "$0($1...)">] abstract Invoke: transaction: Transaction * resultSet: ResultSet -> unit

type [<AllowNullLiteral>] StatementErrorCallback =
    [<Emit "$0($1...)">] abstract Invoke: transaction: Transaction * error: SQLError -> unit

type [<AllowNullLiteral>] Transaction =
    abstract executeSql: sqlStatement: string * ?arguments: obj [] -> Promise<Transaction * ResultSet>

type [<AllowNullLiteral>] TransactionCallback =
    [<Emit "$0($1...)">] abstract Invoke: transaction: Transaction -> unit

type [<AllowNullLiteral>] TransactionErrorCallback =
    [<Emit "$0($1...)">] abstract Invoke: error: SQLError -> unit

type SqlResults =
    class end
    with
        member this.results : ResultSetRowList =
            let y : ResultSet [] = unbox this
            y.[0].rows

type [<AllowNullLiteral>] SQLiteDatabase =
    abstract transaction: scope: (Transaction -> unit) -> Promise<Transaction>
    abstract readTransaction: scope: (Transaction -> unit) -> Promise<TransactionCallback>
    abstract close: unit -> Promise<unit>
    abstract executeSql: statement: string * ?``params``: obj [] -> Promise<SqlResults>
    abstract attach: nameToAttach: string * alias: string -> Promise<unit>
    abstract dettach: alias: string -> Promise<unit>


[<AutoOpen>]
module Helpers =

    let SQLite : IExports = importDefault "react-native-sqlite-storage"
