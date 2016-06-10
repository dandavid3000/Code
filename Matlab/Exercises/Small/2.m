% bai tap 2

clear
clc

% 1. 
x = 1 : 8
y = [1 5 3 2 -6 -6 -1 7]

% 2.
y_tang = sort(y, 'ascend')
y_giam = sort(y, 'descend')

% 3.
z = y.^(1/2)

% 4.
y_median = median(y)
y_sum = sum(y)
y_mean = mean(y)

% 5.
disp('vi tri j: y(j) lon hon 0: ');
find(y > 0)

disp('vi tri j: x(j) > 3 va y(j) < 4: ');
find(x > 3 & y < 4)

% 6.
v = x ./ y
