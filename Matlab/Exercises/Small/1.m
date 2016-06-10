% bai tap 1

clear
clc

% 1. khai bao ma tran
A = [...
    1 2 3;...
    6 5 4;...
    7 8 9]
B = [...
    -1 4 6;...
    2 3 9;...
    6 -8 1]
P = 5 * ones(10,20)

% 2. Thuc hien phep toan
disp('A+B'); A + B
disp('A*B'); A * B
disp('A/B'); A * B^(-1)
disp('A^(-1)'); A^(-1)
disp('A^(1/2)'); A^(1/2)
disp('eij = aij * bij'); E = A .* B

% 3. 
N = A * B;
N = N([2,3],[1,3])

% 4.
C = [A B]
D = [A; B]


