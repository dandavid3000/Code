function W = classify(X, p1,p2,p3,p4,p5,p6)
load bank.mat
n = size(X,1);

p_forge = p5;
p_genuine = p6;

p_x_forge = mvnpdf(X,p1,p3);
p_x_genuine = mvnpdf(X,p2,p4);

gx_forge = p_x_forge * p5;
gx_genuine = p_x_genuine * p6;

W = gx_forge > gx_genuine;

