% Bai 1
% 2.

a = 1;
b = -5;
c = 3;

figure, hold on

% ve do thi ham so y = ax^2 + bx + c
x = -5:0.1:10;
y = a*x.^2 + b*x + c;
plot(x,y)

% ve diem giao voi truc hoanh, tuc la tim nghiem ax^2 + bx + c = 0
X = PTB2(a, b, c);
Y = a*X.^2 + b*X + c;
plot(X, Y, 'r*');

% ve tiep tuyen tai cac diem tim duoc
for i = 1 : numel(X)
    hsg = DaoHamDTB2(X(i), a, b, c); % he so goc
    y = hsg * x - hsg*X(i);
    plot(x, y, 'r-');
end
