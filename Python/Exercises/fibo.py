

def matrix_multiplication(f0, f1):
    lefttop = f0[0][0] * f1[0][0] + f0[0][1] * f1[1][0]
    leftbottom = f0[1][0] * f1[0][0] + f0[1][1] * f1[1][0]
    righttop = f0[0][0] * f1[0][1] + f1[0][1] * f1[1][1]
    rightbottom = f0[1][0] * f1[0][1] + f0[1][1] * f1[1][1]

    f0[0][0] = lefttop;
    f0[1][0] = leftbottom;
    f0[0][1] = righttop;
    f0[1][1] = rightbottom;

def fibo_power(f0, n):
    if n==0 or n==1:
        return f0
    f1 = [[1, 1],[1, 0]]
    fibo_power(f0,int(n/2))
    matrix_multiplication(f0,f0)
    if n%2 != 0:
        matrix_multiplication(f0,f1)
def fibonacci(n):
    f0=[[1, 1],[1, 0]]

    if n==0:
        return 0;
    fibo_power(f0,n-1)
    return f0[0][0]

print fibonacci(100000000)%1000000