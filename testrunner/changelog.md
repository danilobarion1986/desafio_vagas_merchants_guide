TestRunner Changelog
====================


vNext
-----


v1.5
----

-   Support multiple test assemblies in a single `TestRunner` invocation


v1.4
----

-   Stop hanging indefinitely if there are leftover threads, by exiting the program using
    [Environment.Exit](https://msdn.microsoft.com/en-us/library/system.environment.exit.aspx)


v1.3
----

-   Eliminate dependency on `Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll` by using reflection to discover
    and run tests


v1.2
----

-   Don't try to run test or cleanup methods if relevant initialize methods fail


v1.1
----

-   Improve \[ExpectedException\] output

-   Don't crash in environments where the internal framework details required for test assembly `.config` file loading
    aren't present


v1.0
----

-   <https://en.wikipedia.org/wiki/Minimum_viable_product>
