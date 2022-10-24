# def countdown(num):
#     output = []
#     for i in range(num,-1,-1):
#         output.append(i)
#     return output

# count = countdown(5)
# print(count)

# def printAndReturn(num1, num2):
#     print(num1)
#     return num2

# test = printAndReturn(5,52)
# print(test)

# def firstPlusLength(num1):
#     result = num1[0] + len(num1)
#     return result
# test = firstPlusLength([5,2,5,1,19,6])
# print(test)

# def values_greater_than_second(list):
#     if len(list) < 2:
#         return False
#     output = []
#     for i in range(0,len(list)):
#         if list[i] > list[1]:
#             output.append(list[i])
#     print(len(output))
#     return output

# result = values_greater_than_second([3,2,8,1,0,4,6])
# print(result)

# def thisLengthThatValue(length, value):
#     return str(value) * length
# result = thisLengthThatValue(5,4)
# print(result)