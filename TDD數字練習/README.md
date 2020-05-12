    /// <summary>
    /// 英數字重構練習專案 : 修改看看
    /// e.g. input A -> output A
    ///      input B -> output B        ---第一階段側資
    ///      input Aa -> output A-Aa
    ///      input aa -> output A-Aa
    ///      input aA -> output A-Aa
    ///      input AA -> output A-Aa
    ///      input ab -> output A-Bb
    ///      input ba -> output B-Aa
    ///      input abc -> A-Bb-Ccc
    ///      input 無字母 or null -> 丟例外   ---第二階段側資
    ///      input 1 -> output 1
    ///      input a1 -> output A-11
    ///      input 1a -> output 1-Aa
    ///      input 123 -> output 1-22-333
    ///      input a12 -> output A-11-222     ---第三階段側資
    /// </summary>

1. 一開始完全沒有想法 , 所以先從最簡單的開始. 
   - 測資 A->A
   
跑測試

2. 想到除了 A 以外, 應該也要可以輸入別的字 , 所以加入  B->B 的字
   - 因為完成的邏輯是輸入甚麼丟什麼的大寫回去.
   - return $"{char.ToUpper(str[0])}";
   - 所以就沒有再加入 a->A 的測資 , 而是繼續往兩個字的測資邁進    
   
跑測試

3. 列出兩~三個字的側資 以及防呆的側資(輸入是空字串或是null)

跑測試

4. 因為發現測試的程式有重複 , 所以重構測試程式.

跑測試

5. 開始實作兩個字的功能 , 並依照紅燈 , 實作 , 讓他綠燈的流程 , 一個側資一個側資的順序 , 完成.
   - 按照字數去判斷要用一個字的處理方式還是兩個字的處理方式 // if 判斷
   - return $"{char.ToUpper(str[0])}-{char.ToUpper(str[1])}{char.ToLower(str[1])}"; // 一個字的處理方式
   
跑測試

6. 因為兩個字的側資都通過了 , 選擇重構程式
   - 因為看不出來可以做什麼 , 但感覺好像有壞味道 , 所以將變數都抽出來 , 看看效果再決定 .
   - 發現 char.ToUpper 方法被重複呼叫 , 所以抽出方法 ToUpper() & ToLower()
   
跑測試

7. 暫時看不出來可以幹嘛 , 選擇繼續實作三個字的功能

跑測試

8. 暫時看不出來可以幹嘛 , 選擇實作防呆的側資

跑測試

9. 感覺程式碼夠髒了... 開始重構
   - 因為發現重複子字串的部分 , 重複子字串的字數是依照他在原字串的位置而決定的.  這個特性.
   - 抽出 "產生重複子字串的部分" 為方法   
    e.g. Aa
   - private static string GetCorrectFormatStr(char c, int count)
        {
            return string.Concat(Enumerable.Repeat(c, count)
                                           .Select((s, index) => index == 0 ? ToUpper(s) : ToLower(s)));
        }
    
跑測試

10. 繼續重構 , 發現每一個測資都有一個邏輯
    - 依據字數決定要跑幾次 "產生重複子字串的方法" , 最後再講這些字串合併為一個 (使用 - 符號 , 做串接)
    - 將上述動作抽成一個方法
    - str.Select((c,    index) => GetCorrectFormatStr(c, index + 1))
                              .Aggregate((l, r) => $"{l}-{r}");
跑測試

11. 開始按照 Reshaper 的建議 , 重構程式.  e.g. 把方法改成 static 之類的

跑測試

12. 突然想到新的情境 , 輸入好像也可以是數字 , 一個大崩潰 , 想說程式可能都要重寫 T_T
    - 列出可能的數字側資
13.  實作輸入是數字的功能.
    - 發現好像不用修改程式 = =
    
但還是跑測試

14. 按照 Reshaper 的建議 , 重構程式 e.g. 將 if 改成三元運算式

跑測試

15. 補上兩個比較複雜的側資 , 買保險

跑測試



