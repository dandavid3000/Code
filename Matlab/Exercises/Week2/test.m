%clc;
%clear all;
function [] = test( tenfile )
load (tenfile);
n = size(forge,1);
disp('Phan biet tien that gia bang phuong phap Cross Validation'); 
k = 5;
P_forge =1/3;
P_genuine = 2/3;
Ncc = 0;
size_test = round(n / k);
for i = 1 : k 
    D_forge = forge([1:(i-1)*size_test, i*size_test+1:end],:);
    D_forge_test = forge((i-1)*size_test+1:i*size_test,:);
    D_genuine = genuine([1:(i-1)*size_test, i*size_test+1:end],:);
    D_genuine_test = genuine((i-1)*size_test+1:i*size_test,:);
    [p1,p2,p3,p4,p5,p6] =learn(D_forge, D_genuine, P_forge , P_genuine);
    m = size(D_forge_test,1);
    for j = 1: m
        X= D_forge_test(j,:);
        W = classify(X,p1,p2,p3,p4,p5,p6,D_forge ,D_genuine);
        if(W == 1)
            Ncc = Ncc + 1;
        end
    end
    m = size(D_genuine_test,1);
    for j = 1: m
        X= D_genuine_test(j,:);
        W = classify(X,p1,p2,p3,p4,p5,p6,D_forge ,D_genuine);
        if(W == 0)
            Ncc = Ncc + 1;
        end
    end
end
Pcc = Ncc /(size(forge,1) + size(genuine,1));
fprintf(' Ti le phan loai dung la:  %.4f \n',Pcc);
end