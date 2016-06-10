% Bai 1
% tim nghiem cua phuong trinh bac 2: f(x) = ax^2 + bx + c = 0

function x = PTB2(a, b, c)

if a == 0
    if b == 0
        x = []; % phuong trinh vo nghiem
    else
        x = [-c/b]; % phuong trinh co 1 nghiem
    end
else
    delta = b*b - 4*a*c;
    if delta == 0
        x = [-b/(2*a)]; % phuong trinh co nghiem kep
    else
        x = [...        % phuong trinh co 2 nghiem phan biet
            (-b + sqrt(delta)) / (2*a),...
            (-b - sqrt(delta)) / (2*a)];
    end
end