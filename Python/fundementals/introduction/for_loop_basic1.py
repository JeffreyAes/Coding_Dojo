for i in range(0, 151):
    print(i)
    
for i in range(5, 1001, 5):
    print(i)

for i in range(1, 101):
    if i % 10 == 0:
        print("coding dojo")
    elif i % 5 == 0:
        print("coding")
    else: print(i)

sum = 0
for i in range(0, 500_000):
    if i % 2 != 0:
        sum = sum + i
print(sum)
for i in range(2018, 0, -4):
    print(i)

lowNum = 6
highNum = 24
mult = 3
for i in range(lowNum, highNum):
    if i % mult == 0:
        print(i)
