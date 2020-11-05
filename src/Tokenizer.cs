using System;

namespace first
{
    public interface Tokenizer
    {
        String GetNext();

        String GetAndCheckNext(String regex);

        Boolean MoreTokens();
        
        Boolean CheckToken(String regex);
    }
}