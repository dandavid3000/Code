% Bai 2
% Tich phan ban Monte Carlo

function kq = TichPhan2(f, a, b, n)

% tim gia tri min va max cua f(x) trong [a,b]
x = a : 0.001 : b;
y = f(x);
ymin = min([y 0]);
ymax = max([y 0]);

% rai deu n diem len hinh chu nhat [a,b] x [ymin,ymax]
x = unifrnd(a, b, 1, n);
y = unifrnd(ymin, ymax, 1, n); % (x,y) la mang cac diem duoc gieo ngau nhien vao hcn [a,b] x [ymin,ymax]

% tim dien tich phan duong (nam phia tren truc hoanh)
id = find(y > 0);   % index cua cac y > 0
if numel(id) == 0   % neu ko co diem nao thi dien tich = 0
    tp_duong = 0;
else
    y_duong = y(id);
    x_duong = x(id);
    yf_duong = f(x_duong);
    tp_duong = numel(find(y_duong < yf_duong)) / numel(id) * ymax*(b-a); % = tong so diem nam duoi duong y = f(x) / tong so diem 
end


% tim dien tich phan am (nam phia tren truc hoanh)
id = find(y < 0);   % index cua cac y < 0
if numel(id) == 0
    tp_am = 0;
else
    y_am = y(id);
    x_am = x(id);
    yf_am = f(x_am);
    tp_am = numel(find( y_am > yf_am)) / numel(id) * ymin*(b-a); % = tong so diem nam tren duong y = f(x) / tong so diem 
end

% tong dien tich
dt = tp_duong + tp_am;
kq = dt;
