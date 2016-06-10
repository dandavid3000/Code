function Pcc = test(forge,genuine)
load bank.mat
k = 5;

size_test = round(size(forge,1)/k);
Ncc = 0;
for i=1 : k
    D_forge = forge([1:(i-1)*size_test, i*size_test+1:end],:);
    D_forge_test = forge((i-1)*size_test+1:i*size_test,:);
     D_genuine = genuine([1:(i-1)*size_test, i*size_test+1:end],:);
    D_genuine_test = genuine((i-1)*size_test+1:i*size_test,:);
    
    A= [1,1;-2,1];
    B=[1;0];
    P = inv(A)*B;%xac suat tien dinh cua tien gia va tien that
    
    [p1,p2,p3,p4,p5,p6]= learn(D_forge,D_genuine,P(1),P(2));
    
    w_f = classify(D_forge_test,p1,p2,p3,p4,p5,p6);
    w_g = classify(D_genuine_test,p1,p2,p3,p4,p5,p6);
    
    ncc_wf = size(find(w_f == 1),1);
    ncc_wg = size(find(w_g == 0),1);
    
    Ncc = Ncc + ncc_wf + ncc_wg;
    
end
Pcc = Ncc/(size(forge,1) +size(genuine,1));
