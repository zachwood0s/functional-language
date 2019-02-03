target datalayout = "e-m:w-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-pc-windows-msvc19.11.0"

@formatString = private constant [2 x i8] c"%d"

declare i32 @addInt(i32, i32)
declare void @printInt(i32)

define i32 @main(){
  %temp = call i32 @addInt(i32 10, i32 20)
  call void @printInt(i32 %temp)
  ret i32 1
}