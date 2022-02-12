namespace Corth.Core.Exceptions;

public static class ErrorCodes
{
    public const int UnknownError = 0xF0001;

    public const int InvalidToken = 0x00001;
    public const int InvalidLineToken = 0x00002;
    public const int TypeLoadCompile = 0x00003;

    public const int MissingMetadataToken = 0x00004;

    public const int CorthOptionMissing = 0x00005;
    public const int CorthOptionMissingValue = 0xC00006;

    public const int MissingElseOrEndTokenForIf = 0x00007;
    public const int MissingDoTokenForWhile = 0x00008;
    public const int MissingEndTokenForWhile = 0x00009;
    
    public const int FileNotFound = 0x0000A;
    public const int CorthProgramNotLoaded = 0x000B;
    public const int InvalidEndProgram = 0x000C;
    public const int InvalidEndBlockToken = 0x000D;
    public const int MissingEndToken = 0x000F;
    
    public const int RuntimeOperationValueIncompatibleTypes = 0x1001;
    public const int RuntimeOperationInvalidType = 0x1002;
    public const int RuntimeInvalidIfConstruction = 0x1003;
    public const int RuntimeStackInvalidSize = 0x1004;
}