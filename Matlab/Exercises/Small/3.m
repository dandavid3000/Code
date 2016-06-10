% bai tap 3

clear
clc
close all

% 1.
x = -49 : 0.1 : 51;
y1 = x.^3 - 2*x + 1;
y2 = 10*sin(3*x) - 7*cos(2*x);
y3_1 = (50*50 - (x-1).^2).^(1/2) + 30; 
y3_2 = -(50*50 - (x-1).^2).^(1/2) + 30;

figure, hold on
axis([-49 51 -20 80]);
plot(x, y1, 'r-');
plot(x, y2, 'g--');
plot(x, y3_1, x, y3_2, 'b-');
axis square
hold off;

% 2.
x = [1 -1 3 -1 2 3 2 -3];
y = [1 1 -1 2 -1 2 -4 -2];
figure, plot(x,y,'r.');

% 3.
[x, y] = meshgrid(-5:0.1:5, -5:0.1:5);
z = sin(x+y) + cos(x-y);
figure, mesh(x, y, z);