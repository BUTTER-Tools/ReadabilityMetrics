
to build and upload to nuGet:
cd /bin/release
nuget push TextStatistics.<version>.nupkg <nuget_key> -Source https://www.nuget.org/api/v2/package

TextStatistics.Net


Generate information about text including syllable counts and Flesch-Kincaid, Gunning-Fog, Coleman-Liau, SMOG and Automated Readability scores.

A .NET port of [TextStatistics.php](https://github.com/DaveChild/Text-Statistics).

